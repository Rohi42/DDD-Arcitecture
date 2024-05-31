import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BugListComponent } from './components/bug-list/bug-list.component';
import { ViewEditComponent } from './components/view-edit/view-edit.component';
import { AppComponent } from './app.component';
import { MainscreenComponent } from './components/mainscreen/mainscreen.component';

const routes: Routes = [
   {path: 'table', component: BugListComponent},
  {path: '', component:MainscreenComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
