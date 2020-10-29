import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Release } from '../../models/release.model';
import { ReleaseService } from '../../services/release.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-gitlog-release-list',
  templateUrl: './gitlog-release-list.component.html',
  styleUrls: ['./gitlog-release-list.component.css']
})
export class GitlogReleaseListComponent implements OnInit {
  releases: Release[] = [];
  private modalRef;

  constructor(

    private releaseService: ReleaseService,
    private router: Router,
    // public modal: NgbActiveModal,
    // public modalService: NgbModal
  ) { }

  ngOnInit() {
    this.reloadData();
  }

  reloadData() {
    this.releaseService.getAllReleases().subscribe(response => {
      this.releases = response;
    });
  }

  //  deleteCandidato(id: number) {
  //   this.releaseService.deleteRelease(id).subscribe(
  //     data => {
  //       this.reloadData();
  //     },
  //     error => console.log(error)
  //   );
  //   }

  //   get(id: number) {
  //     this.router.navigate(["details", id]);
  //   }

  releaseDetails(id: number) {
    this.router.navigate(["releaseDetails", id]);
  }
}
