import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgSelectConfig } from '@ng-select/ng-select';
import { Project } from 'src/app/models/project.model';
import { Release } from 'src/app/models/release.model';
import { ProjectService } from 'src/app/services/project.service';
import { ReleaseService } from 'src/app/services/release.service';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-gitlog-compare-releases',
  templateUrl: './gitlog-compare-releases.component.html',
  styleUrls: ['./gitlog-compare-releases.component.css']
})
export class GitlogCompareReleasesComponent implements OnInit {

  releasesF: Release[] = [];
  releasesS: Release[] = [];
  projects: Project[] = [];

  projetoBD: Project;
  firstRelease: Release;
  secondRelease: Release;
  comparative: Release;

  constructor(
    private config: NgSelectConfig,
    private projectService: ProjectService,
    private releaseService: ReleaseService,
    private router: Router
    // public modal: NgbActiveModal,
    // public modalService: NgbModal
  ) {
    this.config.notFoundText = 'Not found';
  }
  ngOnInit() {
    this.getProjects();
  }

  public getProjects() {
    this.projectService.getAllProjects()
      .subscribe(data => {
        this.projects = data;
      }, error => {});
  }

  public getReleases(obj: any) {
    if (isNullOrUndefined(obj) || obj.id === 0) {
      this.clearObj();
    } else {
      this.releaseService.getReleaseByProject(obj.id).subscribe(response => {
        this.releasesF = response;
        this.releasesS = response;
      });
    }
  }

  setObj(obj: any) {
    if(this.verifyObj()) {
      this.comparative = new Release(); {
        this.comparative.commits = this.firstRelease.commits - this.secondRelease.commits;
        this.comparative.addedLines = this.firstRelease.addedLines - this.secondRelease.addedLines;
        this.comparative.removedLines = this.firstRelease.removedLines - this.secondRelease.removedLines;
        this.comparative.authors = this.firstRelease.authors - this.secondRelease.authors;
      }      
    } else {  
      this.comparative = null;
    }
  }

  public verifyObj() : boolean {
    return (isNullOrUndefined(this.projetoBD) || isNullOrUndefined(this.firstRelease)||  isNullOrUndefined(this.secondRelease)) ? false : true;
  }

  public clearObj() {
    this.projects = null;
    this.releasesF = null;
    this.releasesS = null;
    this.comparative = null;
    this.firstRelease = null;
    this.secondRelease = null;
  }
}
