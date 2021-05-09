import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiService, DebtsService } from './services';

@NgModule({
  imports: [CommonModule],
  providers: [ApiService, DebtsService],
  declarations: [],
})
export class CoreModule {}
