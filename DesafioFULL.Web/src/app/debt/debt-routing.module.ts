import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DebtListPageComponent } from './pages/debt-list-page/debt-list-page.component';
import { DebtNewPageComponent } from './pages/debt-new-page/debt-new-page.component';

const routes: Routes = [
  { path: '', component: DebtListPageComponent },
  { path: 'new', component: DebtNewPageComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DebtRoutingModule {}
