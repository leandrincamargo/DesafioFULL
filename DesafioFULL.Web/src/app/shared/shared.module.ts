import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MaterialModule } from './material.module';
import { NgxMaskModule } from 'ngx-mask';

import { ToolbarComponent } from './layout';
import { InstallmentComponent, InstallmentDialogComponent } from './components';
import { CapitalizeFirstPipe } from './pipes';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    NgxMaskModule.forRoot(),
  ],
  declarations: [
    InstallmentComponent,
    InstallmentDialogComponent,
    ToolbarComponent,
    CapitalizeFirstPipe,
  ],
  exports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    InstallmentComponent,
    ToolbarComponent,
    CapitalizeFirstPipe,
    NgxMaskModule,
  ],
})
export class SharedModule {}
