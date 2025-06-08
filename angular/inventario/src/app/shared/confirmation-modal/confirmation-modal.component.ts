import { Component, ElementRef, EventEmitter, Input, Output, ViewChild, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-confirmation-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './confirmation-modal.component.html',
})
export class ConfirmationModalComponent implements AfterViewInit {
  @Input() title: string = 'Confirmar Ação';
  @Input() message: string = 'Você tem certeza?';

  @Output() confirmed = new EventEmitter<boolean>();

  @ViewChild('modalElement') modalElement!: ElementRef;

  private modalInstance!: Modal;

  ngAfterViewInit(): void {
    this.modalInstance = new Modal(this.modalElement.nativeElement);
  }

  open(): void {
    this.modalInstance.show();
  }

  confirm(): void {
    this.modalInstance.hide();
    this.confirmed.emit(true);
  }

  dismiss(): void {
    this.modalInstance.hide();
    this.confirmed.emit(false);
  }
}