import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProdutoService } from '../../services/produto.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule, Location } from '@angular/common';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-produto-form',
  imports:[
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.scss'],
  standalone: true
})
export class ProdutoFormComponent implements OnInit {
  form: FormGroup;
  produtoId: string | null = null;

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
    private toastService: ToastService
  ) {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.maxLength(100)]],
      preco: [0, [Validators.required, Validators.min(0.01)]],
      quantidade: [0, [Validators.required, Validators.min(0)]],
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.produtoId = id;
        this.carregarProduto(id);
      }
    });
  }

  carregarProduto(id: string): void {
    this.produtoService.getById(id).subscribe({
      next: (produto) => {
        this.form.patchValue(produto);
      },
      error: (err) => {
        this.toastService.show('Produto não encontrado.', 'danger');
        this.router.navigate(['/produtos']);
      }
    });
  }

  salvar(): void {
    if (this.form.invalid) {
      this.toastService.show('Por favor, preencha todos os campos corretamente.', 'warning');
      return;
    }

    if (this.produtoId) {
      const produtoAtualizado = { id: this.produtoId, ...this.form.value };
      this.produtoService.update(produtoAtualizado).subscribe({
        next: () => {
          this.toastService.show('Produto atualizado com sucesso!', 'success');
          this.router.navigate(['/produtos']);
        },
        error: (err) => this.tratarErro(err, 'atualizar')
      });
    } else {
      this.produtoService.create(this.form.value).subscribe({
        next: () => {
          this.toastService.show('Produto criado com sucesso!', 'success');
          this.router.navigate(['/produtos']);
        },
        error: (err) => this.tratarErro(err, 'criar')
      });
    }
  }
  
  cancelar(): void {
    this.location.back();
  }
  
  private tratarErro(err: any, acao: string): void {
    this.toastService.show(`Ocorreu um erro ao tentar ${acao} o produto.`, 'danger');
  }
}