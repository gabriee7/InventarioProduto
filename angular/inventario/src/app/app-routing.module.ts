import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


export const routes: Routes = [
  { path: '', redirectTo: 'produtos', pathMatch: 'full' },

  {
    path: 'produtos',
    loadChildren: () => import('./domains/produto/produto.module').then(m => m.ProdutoModule)
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }