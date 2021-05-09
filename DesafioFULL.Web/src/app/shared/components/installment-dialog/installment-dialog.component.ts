import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-installment-dialog',
  templateUrl: './installment-dialog.component.html',
  styleUrls: ['./installment-dialog.component.scss'],
})
export class InstallmentDialogComponent {
  installmentForm = this.fb.group({
    number: [null, Validators.required],
    dueDate: [null, Validators.required],
    value: [null, Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<InstallmentDialogComponent>,
  ) {}

  onAdd() {
    if (this.installmentForm.valid) this.dialogRef.close(this.installmentForm.value);
    else alert('Formulário inválido');
  }
}
