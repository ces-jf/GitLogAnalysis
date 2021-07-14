import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoListComponent } from './candidato-list/candidato-list.component';
import { CandidatoCreateComponent } from './candidato-create/candidato-create.component';
import { CandidatoDetailsComponent } from './candidato-details/candidato-details.component';
import { CandidatoUpdateComponent } from './candidato-update/candidato-update.component';
import { CandidatoCalcularComponent } from './candidato-calcular/candidato-calcular.component';
import { GitlogCreateReleaseComponent } from './pages/gitlog/gitlog-create-release/gitlog-create-release.component';
import { GitlogCompareReleasesComponent } from './pages/gitlog/gitlog-compare-releases/gitlog-compare-releases.component';
import { GitlogReleaseListComponent } from './pages/gitlog/gitlog-release-list/gitlog-release-list.component';
import { GitlogReleaseDetailsComponent } from './pages/gitlog/gitlog-release-details/gitlog-release-details.component';
import { ProjectCreateComponent } from './pages/project/project-create/project-create.component';
import { ProjectListComponent } from './pages/project/project-list/project-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'releaseList', pathMatch: 'full' },
  { path: 'releaseCreate', component: GitlogCreateReleaseComponent },
  { path: 'releaseCompare', component: GitlogCompareReleasesComponent },
  { path: 'releaseList', component: GitlogReleaseListComponent },
  { path: 'releaseDetails/:id', component: GitlogReleaseDetailsComponent },
  { path: 'projectCreate', component: ProjectCreateComponent },
  { path: 'projectList', component: ProjectListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
