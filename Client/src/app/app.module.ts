import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidatoListComponent } from './candidato-list/candidato-list.component';
import { HttpClientModule } from '@angular/common/http';
import { CandidatoCreateComponent } from './candidato-create/candidato-create.component';
import { CandidatoUpdateComponent } from './candidato-update/candidato-update.component';
import { CandidatoDetailsComponent } from './candidato-details/candidato-details.component';
import { FormsModule } from '@angular/forms';
import { CandidatoCalcularComponent } from './candidato-calcular/candidato-calcular.component';
import { GitlogCreateReleaseComponent } from './pages/gitlog/gitlog-create-release/gitlog-create-release.component';
import { GitlogCompareReleasesComponent } from './pages/gitlog/gitlog-compare-releases/gitlog-compare-releases.component';
import { GitlogReleaseListComponent } from './pages/gitlog/gitlog-release-list/gitlog-release-list.component';
import { GitlogReleaseDetailsComponent } from './pages/gitlog/gitlog-release-details/gitlog-release-details.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ProjectCreateComponent } from './pages/project/project-create/project-create.component';
import { ProjectListComponent } from './pages/project/project-list/project-list.component';

@NgModule({
   declarations: [
      AppComponent,
      CandidatoListComponent,
      CandidatoCreateComponent,
      CandidatoUpdateComponent,
      CandidatoDetailsComponent,
      CandidatoCalcularComponent,
      CandidatoCalcularComponent,
      GitlogCreateReleaseComponent,
      GitlogCompareReleasesComponent,
      GitlogReleaseListComponent,
      GitlogReleaseDetailsComponent,
      ProjectCreateComponent,
      ProjectListComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      NgSelectModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
