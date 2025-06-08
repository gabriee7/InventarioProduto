import { Component, OnInit, ViewChild } from '@angular/core';
import { ProdutoService } from '../../services/produto.service';
import { Produto } from '../../models/produto.model';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ToastService } from '../../services/toast.service';
import { ConfirmationModalComponent } from '../../../../shared/confirmation-modal/confirmation-modal.component';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  standalone: true,
  selector: 'app-produto-list',
  imports:[
    CommonModule,
    ReactiveFormsModule,
    RouterLink,
    ConfirmationModalComponent ,
    NgxPaginationModule
  ],
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.scss']
})
export class ProdutoListComponent implements OnInit {
  @ViewChild('confirmModal') private modalComponent!: ConfirmationModalComponent;
  produtos: Produto[] = [];
  loading = true;
  private idParaRemover: string | null = null; 
  totalItems: number = 0;
  currentPage: number = 1;
  pageSize: number = 10;
  
  totalPages: number = 0;
  pages: number[] = [];

  constructor(private produtoService: ProdutoService, private toastService: ToastService) {}

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.loading = true;
    this.produtoService.getAll(this.currentPage, this.pageSize).subscribe({
      next: (result) => {
        this.produtos = result.items;
        this.totalItems = result.totalCount;

        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
        this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);

        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        this.toastService.show('Falha ao carregar produtos.', 'danger');
      }
    });
  }


  onPageChange(pageNumber: number): void {
    if (pageNumber < 1 || pageNumber > this.totalPages) {
      return;
    }
    this.currentPage = pageNumber;
    this.carregarProdutos();
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