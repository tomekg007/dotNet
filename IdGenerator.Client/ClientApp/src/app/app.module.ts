import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { CategoryComponent } from './category/category.component';
import Factorycomponent = require("./factory/factory.component");
import FactoryComponent = Factorycomponent.FactoryComponent;
import Factorypartscomponent = require("./factory-parts/factory-parts.component");
import FactoryPartsComponent = Factorypartscomponent.FactoryPartsComponent;


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CategoryComponent,
    FactoryComponent,
    FactoryPartsComponent


  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CategoryComponent, pathMatch: 'full' },
      { path: 'category', component: CategoryComponent },
      { path: 'factory', component: FactoryComponent },
      { path: 'factory-parts', component: FactoryPartsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
