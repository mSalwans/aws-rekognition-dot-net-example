import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { DetectLabelsComponent } from './detect-labels/detect-labels.component';
import { CompareFacesComponent } from './compare-faces/compare-faces.component';
import { ImageToTextComponent } from './image-to-text/image-to-text.component';
import { RecognizeCelebritiesComponent } from './recognize-celebrities/recognize-celebrities.component';

const routes: Routes = [
  { path: 'detectLabels',
    component: DetectLabelsComponent,
    pathMatch: 'full'
  },
  { path: 'compareFaces',
    component: CompareFacesComponent,
    pathMatch: 'full'
  },
  { path: 'imageToText',
    component: ImageToTextComponent,
    pathMatch: 'full'
  },
  { path: 'recognizeCelebrities',
    component: RecognizeCelebritiesComponent,
    pathMatch: 'full'
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'detectLabels'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
