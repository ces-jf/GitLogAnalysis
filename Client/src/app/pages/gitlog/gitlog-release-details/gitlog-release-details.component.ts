import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Release } from 'src/app/models/release.model';
import { ReleaseService } from 'src/app/services/release.service';

@Component({
  selector: 'app-gitlog-release-details',
  templateUrl: './gitlog-release-details.component.html',
  styleUrls: ['./gitlog-release-details.component.css']
})
export class GitlogReleaseDetailsComponent implements OnInit {

  id: number;
  release: Release;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private releaseService: ReleaseService) { }

  ngOnInit() {
    this.release = new Release();
    this.id = this.route.snapshot.params.id;
    this.releaseService.getById(this.id)
      .subscribe(data => {
        this.release = data;
      }, error => {});

  }

  releaseList() {
    this.router.navigate(["releaseList"]);
  }


}
