import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { CandidatoServiceService } from "../candidatoService.service";
import { Candidato } from "../candidato.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-candidato-list",
  templateUrl: "./candidato-list.component.html",
  styleUrls: ["./candidato-list.component.css"]
})
export class CandidatoListComponent implements OnInit {
  responseUsers: Candidato[] = [];

  constructor(
    private candidatoService: CandidatoServiceService,
    private router: Router
  ) {}

  ngOnInit() {
    this.reloadData();
  }

  reloadData() {
    this.candidatoService.getUsers().subscribe(response => {
      this.responseUsers = response;
    });
  }

  deleteCandidato(id: number) {
    this.candidatoService.deleteCandidato(id).subscribe(
      data => {
        console.log(data);
        this.reloadData();
      },
      error => console.log(error)
    );
  }

  get(id: number) {
    this.router.navigate(["details", id]);
  }

  detailsCandidato(id: number) {
    this.router.navigate(["details", id]);
  }

  updateCandidato(id: number) {
    this.router.navigate(["update", id]);
  }
}
