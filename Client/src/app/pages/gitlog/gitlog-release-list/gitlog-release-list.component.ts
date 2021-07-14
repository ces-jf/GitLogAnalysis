import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Release } from '../../../models/release.model';
import { ReleaseService } from '../../../services/release.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectService } from 'src/app/services/project.service';
import { Project } from 'src/app/models/project.model';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-gitlog-release-list',
  templateUrl: './gitlog-release-list.component.html',
  styleUrls: ['./gitlog-release-list.component.css']
})
export class GitlogReleaseListComponent implements OnInit {
  releases: Release[] = [];
  private modalRef;
  projects: any;
  projetoBD: Project;

  constructor(
    private projectService: ProjectService,
    private releaseService: ReleaseService,
    private router: Router,
    // public modal: NgbActiveModal,
    // public modalService: NgbModal
  ) { }

  ngOnInit() {
    this.getProjects();
    this.releases=null;
  }

  reloadData(obj: any) {
    if (isNullOrUndefined(obj) || obj.id === 0) {
      this.releases = null;
    } else {
      this.releaseService.getReleaseByProject(obj.id).subscribe(response => {
        this.releases = isNullOrUndefined(response) || response === [] ? null : response;
      });
    }
  }

  public getProjects() {
    this.projectService.getAllProjects()
      .subscribe(data => {
        this.projects = data;
      }, error => {});
  }

  releaseDetails(id: number) {
    this.router.navigate(["releaseDetails", id]);
  }
}
