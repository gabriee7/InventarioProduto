import { Component, OnInit, ViewChild } from '@angular/core';
import { ProdutoService } from '../../services/produto.service';
import { Produto } from '../../models/produto.model';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ToastService } from '../../services/toast.service';
import { ConfirmationModalComponent } from '../../../../shared/confirmation-modal/confirmation-modal.component';

@Component({
  standalone: true,
  selector: 'app-produto-list',
  imports:[
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    ConfirmationModalComponent 
  ],
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.scss']
})
export class ProdutoListComponent implements OnInit {
  @ViewChild('confirmModal') private modalComponent!: ConfirmationModalComponent;
  produtos: Produto[] = [];
  loading = true;
  private idParaRemover: string | null = null; 
  constructor(private produtoService: ProdutoService, private toastService: ToastService) {}

  ngOnInit(): void {
    this.produtoService.getAll().subscribe({
      next: (result) => {
        this.produtos = result.items;
        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
      }
    });
  }

  remover(id: string): void {
    this.idParaRemover = id;
    this.modalComponent.open();
  }

  onConfirmation(confirmado: boolean): void {
    if (confirmado && this.idParaRemover) {
      this.produtoService.delete(this.idParaRemover).subscribe({
        next: () => {
          this.produtos = this.produtos.filter(p => p.id !== this.idParaRemover);
          this.toastService.show('Produto removido com sucesso!', 'success'); 
          this.idParaRemover = null;
        },
        error: (err) => {
          this.toastService.show('Ocorreu um erro ao remover o produto.', 'danger');
          this.idParaRemover = null;
        }
      });
    } else {
      this.idParaRemover = null;
    }
  }
}