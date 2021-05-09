import { NgModule } from '@angular/core';
import { NgxMaskModule } from 'ngx-mask';

import { SharedModule } from '../shared';

import { DebtRoutingModule } from './debt-routing.module';

import { DebtListPageComponent } from './pages/debt-list-page/debt-list-page.component';
import { DebtNewPageComponent } from './pages/debt-new-page/debt-new-page.component';

@NgModule({
  declarations: [DebtListPageComponent, DebtNewPageComponent],
  imports: [SharedModule, DebtRoutingModule],
})
export class DebtModule {}
