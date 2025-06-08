import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoRoutingModule } from './produto-routing.module';
import { ProdutoComponent } from './produto.component';
import { ProdutoListComponent } from './pages/produto-list/produto-list.component';
import { ProdutoFormComponent } from './pages/produto-form/produto-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
  ],
  imports: [
    ProdutoListComponent,
    CommonModule,
    ReactiveFormsModule,
    ProdutoComponent,
    ProdutoFormComponent,
    ProdutoRoutingModule
  ]
})
export class ProdutoModule {}