import { Component, Inject, OnInit } from '@angular/core';
import { Validators, NgForm } from '@angular/forms';
import Client = require("@angular/common/http/src/client");
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Component({
  selector: 'app-factory-parts',
  templateUrl: './factory-parts.component.html'
})


export class FactoryPartsComponent implements OnInit {
  public categories: Category[] = [];
  public factory: Factory[] = [];
  public factoryParts: FactoryParts[] = [];
  public createFactoryPart = {};

  public selectedCategory : string;
  public selectedFactory;

  
  public category = {};
  private uri = 'http://localhost:64098/api/';


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.getCategories();
    this.getFactory();
    this.getFactoryParts();
  }

  getCategories() {
    this.http.get<Category[]>(this.uri + 'Category').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }

  getFactory() {
    this.http.get<Factory[]>(this.uri + 'Factory').subscribe(result => {
      this.factory = result;
    }, error => console.error(error));
  }

  getFactoryParts() {
    this.http.get<FactoryParts[]>(this.uri + 'FactoryParts').subscribe(result => {
      this.factoryParts = result;
    }, error => console.error(error));
  }

  getFactoryPart(categoryId , factoryId, number ) {
    this.http.get<FactoryParts>(this.uri + '/FactoryParts' + categoryId + '/' + factoryId + '/' + number).subscribe(result => {
      this.factoryParts.push(result);
    }, error => console.error(error));
  }

  add(categoryId, factoryId) {
    let factoryPart = {
      categoryId: categoryId,
      factoryId: factoryId
    }
    
    this.http.post(this.uri + 'FactoryParts', factoryPart)
      .subscribe(res => this.getFactoryParts());
  }
}

interface Category {
  id: string;
  name: number;
}

interface Factory {
  id: string;
  name: number;
}

interface FactoryParts {
  id: string;
  createdAt: Date;
}

interface CreateFactoryPart {
  categoryId: string;
  factoryId: string;
}
