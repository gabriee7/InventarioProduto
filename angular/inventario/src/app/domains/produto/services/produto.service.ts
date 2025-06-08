import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Produto } from '../models/produto.model';
import { Observable } from 'rxjs';
import { PagedResult } from '../models/paged-result.model';
import { environment } from '../../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ProdutoService {
  private apiUrl = `${environment.apiUrl}/Produto`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<PagedResult<Produto>> {
    return this.http.get<PagedResult<Produto>>(`${this.apiUrl}/GetAll`);
  }

  getById(id: string): Observable<Produto> {
    return this.http.get<Produto>(`${this.apiUrl}/GetById?id=${id}`);
  }

  create(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(`${this.apiUrl}/Create`, produto);
  }

  update(produto: Produto): Observable<Produto> {
    return this.http.put<Produto>(`${this.apiUrl}/Update`, produto);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Delete?id=${id}`);
  }
}
