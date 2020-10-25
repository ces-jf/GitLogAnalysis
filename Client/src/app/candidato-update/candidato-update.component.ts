import { Component, OnInit } from '@angular/core';
import { Candidato } from '../candidato.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidatoServiceService } from '../candidatoService.service';

@Component({
  selector: 'app-candidato-update',
  templateUrl: './candidato-update.component.html',
  styleUrls: ['./candidato-update.component.css']
})
export class CandidatoUpdateComponent implements OnInit {

  id: number;
  candidato: Candidato;

  constructor(private route: ActivatedRoute, private router: Router,
              private candidatoService: CandidatoServiceService) { }

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.candidatoService.get(this.id)
      .subscribe(data => {
        console.log(data);
        this.candidato = data;
      }, error => console.log(error));
  }

  updateCandidato() {
    this.candidatoService.updateCandidato(this.id, this.candidato)
      .subscribe(data => {
        console.log(data);
        this.candidato = new Candidato();
        this.gotoList();
      }, error => console.log(error));
  }

  onSubmit() {
    this.updateCandidato();
  }

  gotoList() {
    this.router.navigate(['/candidatos']);
  }
}
