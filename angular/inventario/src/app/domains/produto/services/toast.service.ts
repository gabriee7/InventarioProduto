import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

export type ToastType = 'success' | 'danger' | 'warning' | 'info';

export interface Toast {
  message: string;
  type: ToastType;
  delay?: number;
}

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private toastSubject = new Subject<Toast>();

  public toasts$ = this.toastSubject.asObservable();

  constructor() { }

  show(message: string, type: ToastType = 'info', delay: number = 5000): void {
    this.toastSubject.next({ message, type, delay });
  }
}