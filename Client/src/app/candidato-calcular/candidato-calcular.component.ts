import { Component, OnInit } from '@angular/core';
import { CandidatoServiceService } from '../candidatoService.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-candidato-calcular',
  templateUrl: './candidato-calcular.component.html',
  styleUrls: ['./candidato-calcular.component.css']
})
export class CandidatoCalcularComponent implements OnInit {

  numVagas: any;

  constructor(
    private candidatoService: CandidatoServiceService,
    private router: Router) { }
  

  ngOnInit() {
  }

  exibirResultados() {
    this.candidatoService.exibirResultados(this.numVagas).subscribe(data => {
      console.log(data);
      this.router.navigate(['candidato']);
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.router.navigate(['candidato']);
  }
}
