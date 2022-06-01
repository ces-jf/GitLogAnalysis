import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { GitlogCreateReleaseComponent } from './pages/gitlog/gitlog-create-release/gitlog-create-release.component';
import { GitlogCompareReleasesComponent } from './pages/gitlog/gitlog-compare-releases/gitlog-compare-releases.component';
import { GitlogReleaseListComponent } from './pages/gitlog/gitlog-release-list/gitlog-release-list.component';
import { GitlogReleaseDetailsComponent } from './pages/gitlog/gitlog-release-details/gitlog-release-details.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ProjectCreateComponent } from './pages/project/project-create/project-create.component';
import { ProjectListComponent } from './pages/project/project-list/project-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
   declarations: [
      AppComponent,
      GitlogCreateReleaseComponent,
      GitlogCompareReleasesComponent,
      GitlogReleaseListComponent,
      GitlogReleaseDetailsComponent,
      ProjectCreateComponent,
      ProjectListComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      NgSelectModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
