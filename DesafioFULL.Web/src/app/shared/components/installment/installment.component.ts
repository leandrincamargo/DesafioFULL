import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

import { InstallmentDtoRequest } from 'src/app/core';
import { InstallmentDialogComponent } from '../installment-dialog';

@Component({
  selector: 'app-installment',
  templateUrl: './installment.component.html',
  styleUrls: ['./installment.component.scss'],
})
export class InstallmentComponent implements OnInit {
  // @Input() installments: InstallmentDtoRequest[] = [];
  _installments = new MatTableDataSource<InstallmentDtoRequest>();
  @Input() set installments(val: InstallmentDtoRequest[]) {
    this.installmentsChange.emit(val);
    this._installments = new MatTableDataSource<InstallmentDtoRequest>(val);
  }
  @Output() installmentsChange: EventEmitter<InstallmentDtoRequest[]> = new EventEmitter<
    InstallmentDtoRequest[]
  >();

  public displayedColumns: string[] = ['number', 'dueDate', 'value'];

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {}

  onNewInstallment() {
    const installmentDialog = this.dialog.open(InstallmentDialogComponent, {
      width: '300px',
    });

    installmentDialog.afterClosed().subscribe((result: InstallmentDtoRequest) => {
      if (result) {
        let array = this._installments.data;
        array.push(result);
        this._installments = new MatTableDataSource<InstallmentDtoRequest>(array);
        this.installmentsChange.emit(array);
      }
    });
  }
}
