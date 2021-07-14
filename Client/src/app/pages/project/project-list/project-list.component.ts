import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from 'src/app/models/project.model';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit {
  
  projects: Project[] = [];
  private modalRef;

  constructor(

    private projectService: ProjectService,
    private router: Router,)
    { }
  ngOnInit() {
    this.reloadData();
  }
  
  reloadData() {
    this.projectService.getAllProjects().subscribe(response => {
      this.projects = response;
    });
  }

}
