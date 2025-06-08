import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { Toast, ToastService } from '../../domains/produto/services/toast.service';

@Component({
  selector: 'app-toast-container',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './toast-container.component.html',
  styleUrls: ['./toast-container.component.scss']
})
export class ToastContainerComponent implements OnInit, OnDestroy {
  toasts: Toast[] = [];
  private subscription: Subscription = new Subscription();

  constructor(private toastService: ToastService) { }

  ngOnInit(): void {
    this.subscription = this.toastService.toasts$.subscribe(toast => {
      this.toasts.push(toast);

      setTimeout(() => this.removeToast(toast), toast.delay || 5000);
    });
  }

  removeToast(toastToRemove: Toast): void {
    this.toasts = this.toasts.filter(toast => toast !== toastToRemove);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}