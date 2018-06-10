import { Component, Inject, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import Client = require("@angular/common/http/src/client");
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Component({
  selector: 'app-factory-component',
  templateUrl: './factory.component.html'
})


export class FactoryComponent implements OnInit {
  public factory: Factory[] = [];
  public category = {};
  private uri = 'http://localhost:64098/api/Factory';


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.http.get<Factory[]>(this.uri).subscribe(result => {
      this.factory = result;
    }, error => console.error(error));
  }

  get(id) {
    this.http.get<Factory>(this.uri + '/' + id).subscribe(result => {
      this.factory.push(result);
    }, error => console.error(error));
  }

  add(category: Factory) {
    this.http.post(this.uri, category)
      .subscribe(res => this.get(category.id));
  }
}

interface Factory {
  id: string;
  name: number;
}
