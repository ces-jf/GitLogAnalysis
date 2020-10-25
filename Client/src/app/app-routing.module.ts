import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoListComponent } from './candidato-list/candidato-list.component';
import { CandidatoCreateComponent } from './candidato-create/candidato-create.component';
import { CandidatoDetailsComponent } from './candidato-details/candidato-details.component';
import { CandidatoUpdateComponent } from './candidato-update/candidato-update.component';
import { CandidatoCalcularComponent } from './candidato-calcular/candidato-calcular.component';


const routes: Routes = [
  {path: 'candidato-list', component: CandidatoListComponent},
  {path: 'candidato-create', component: CandidatoCreateComponent},
  { path: '', redirectTo: 'candidatos', pathMatch: 'full' },
  { path: 'candidato', component: CandidatoListComponent },
  { path: 'candidatos', component: CandidatoListComponent },
  { path: 'add', component: CandidatoCreateComponent },
  { path: 'update/:id', component: CandidatoUpdateComponent },
  { path: 'details/:id', component: CandidatoDetailsComponent },
  { path: 'exibirResultados', component: CandidatoCalcularComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
