import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgSelectConfig } from '@ng-select/ng-select';
import { Release } from 'src/app/models/release.model';
import { ReleaseService } from 'src/app/services/release.service';

@Component({
  selector: 'app-gitlog-compare-releases',
  templateUrl: './gitlog-compare-releases.component.html',
  styleUrls: ['./gitlog-compare-releases.component.css']
})
export class GitlogCompareReleasesComponent implements OnInit {

  releasesF: Release[] = [];
  releasesS: Release[] = [];

  firstRelease: Release;
  secondRelease: Release;
  comparative: Release;

  constructor(
    private config: NgSelectConfig,
    private releaseService: ReleaseService,
    private router: Router
    // public modal: NgbActiveModal,
    // public modalService: NgbModal
  ) {
    this.config.notFoundText = 'Custom not found';
  }
  ngOnInit() {
    this.releaseService.getAllReleases().subscribe(response => {
      this.releasesF = response;
      this.releasesS = response;
      console.log(response);
     });


  }

  setObj(obj: any) {
    this.comparative = new Release(); {
      this.comparative.commits = this.firstRelease.commits - this.secondRelease.commits;
      this.comparative.addedLines = this.firstRelease.addedLines - this.secondRelease.addedLines;
      this.comparative.removedLines = this.firstRelease.removedLines - this.secondRelease.removedLines;
      this.comparative.authors = this.firstRelease.authors - this.secondRelease.authors;
    }
    console.log(obj);
  }
}
