import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadComponent } from './shared/upload/upload.component';
import { HttpClientModule } from '@angular/common/http';
import { DetectLabelsComponent } from './detect-labels/detect-labels.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatSidenavModule, MatIconModule, MatListModule, MatToolbarModule, MatChipsModule, MatProgressSpinnerModule, MatSnackBarModule} from '@angular/material';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CompareFacesComponent } from './compare-faces/compare-faces.component';
import { AppHelper } from './app-helper';
import { ImageToTextComponent } from './image-to-text/image-to-text.component';
import { RecognizeCelebritiesComponent } from './recognize-celebrities/recognize-celebrities.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    DetectLabelsComponent,
    HomeComponent,
    PageNotFoundComponent,
    CompareFacesComponent,
    ImageToTextComponent,
    RecognizeCelebritiesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule, 
    MatCheckboxModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatToolbarModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    MatSnackBarModule
  ],
  providers: [AppHelper],
  bootstrap: [AppComponent]
})
export class AppModule { }
