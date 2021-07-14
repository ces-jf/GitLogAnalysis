import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FrontParams } from 'src/app/models/frontParams.model';
import { ProjectService } from 'src/app/services/project.service';
import { Release } from '../../../models/release.model';
import { ReleaseService } from '../../../services/release.service';

@Component({
  selector: 'app-gitlog-create-release',
  templateUrl: './gitlog-create-release.component.html',
  styleUrls: ['./gitlog-create-release.component.css']
})
export class GitlogCreateReleaseComponent implements OnInit {

  frontP: FrontParams = new FrontParams();
  projects: any;

  submitted = false;

  constructor(
    private projectService: ProjectService,
    private releaseService: ReleaseService,
    private router: Router) { }

  ngOnInit() {
    this.getProjects();
  }

  newRelease(): void {
    this.submitted = false;
    this.frontP = new FrontParams();
  }

  getProjects() {
    this.projectService.getAllProjects()
      .subscribe(data => {
        this.projects = data;
      })
  }

  save() {
    this.releaseService.createRelease(this.frontP)
      .subscribe(data => {
        this.frontP = new FrontParams();
        this.gotoList();
      }, error => { });

  }
  onSubmit() {
    this.submitted = true;
    this.save();
  }
  gotoList() {
    this.router.navigate(['/releaseList']);
  }
}
