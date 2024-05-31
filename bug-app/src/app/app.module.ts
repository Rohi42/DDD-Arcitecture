import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { HttpClientModule } from '@angular/common/http';
import { BugListComponent } from './components/bug-list/bug-list.component';
import {MatTableModule} from '@angular/material/table';
import { ViewEditComponent } from './components/view-edit/view-edit.component';
import {MatDialogModule} from '@angular/material/dialog';
import{MatFormFieldModule} from '@angular/material/form-field';
import{MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MainscreenComponent } from './components/mainscreen/mainscreen.component';

@NgModule({
  declarations: [
    AppComponent,
    BugListComponent,
    ViewEditComponent,
    MainscreenComponent
  ],
  imports: [
    MatCheckboxModule,
    ReactiveFormsModule,
    FormsModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatMenuModule,
    HttpClientModule,
    RouterModule,
    MatTableModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatCardModule
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
