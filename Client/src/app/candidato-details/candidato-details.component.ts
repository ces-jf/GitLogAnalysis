import { Component, OnInit, Input } from '@angular/core';
import { Candidato } from '../candidato.model';
import { CandidatoListComponent } from '../candidato-list/candidato-list.component';
import { Router, ActivatedRoute } from '@angular/router';
import { CandidatoServiceService } from '../candidatoService.service';

@Component({
  selector: 'app-candidato-details',
  templateUrl: './candidato-details.component.html',
  styleUrls: ['./candidato-details.component.css']
})
export class CandidatoDetailsComponent implements OnInit {

  id: number;
  candidato: Candidato;

  constructor(private route: ActivatedRoute, private router: Router,
              private candidatoService: CandidatoServiceService) { }

  ngOnInit() {
    this.candidato = new Candidato();

    this.id = this.route.snapshot.params.id;
    this.candidatoService.get(this.id)
      .subscribe(data => {
        console.log(data);
        this.candidato = data;
      }, error => console.log(error));

  }

  list() {
    this.router.navigate(['candidatos']);
  }

}
