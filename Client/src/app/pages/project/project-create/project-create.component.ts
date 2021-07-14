import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectParams } from 'src/app/models/projectParam.model';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project-create',
  templateUrl: './project-create.component.html',
  styleUrls: ['./project-create.component.scss']
})
export class ProjectCreateComponent implements OnInit {
  
  public projectP = new ProjectParams();
  projects: any;

  submitted = false;

  constructor(
    public projectService: ProjectService,
    private router: Router
    ) { }

  ngOnInit() {
  }

  newRelease(): void {
    this.submitted = false;
  }

  getProjects() {
    this.projectService.getAllProjects()
    .subscribe(data => {
      this.projects = data;
    })
  }

  save() {
    debugger
    this.projectService.createProject(this.projectP)
      .subscribe(data => {
          this.projectP = new ProjectParams();
        this.gotoList();
      }, error => {});
  }

  onSubmit() {
    this.submitted = true;
    this.save();
  }
  gotoList() {
    this.router.navigate(['/projectList']);
  }
}
