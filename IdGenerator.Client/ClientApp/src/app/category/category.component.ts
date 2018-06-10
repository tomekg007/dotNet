import { Component, Inject, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import Client = require("@angular/common/http/src/client");
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Component({
  selector: 'app-factory',
  templateUrl: './category.component.html',
})


export class CategoryComponent implements OnInit{
  public categories: Category[] = [];
  public category = {};
  private uri = 'http://localhost:64098/api/Category';


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {}

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.http.get<Category[]>(this.uri).subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }

  get(id) {
    this.http.get<Category>(this.uri + '/' + id).subscribe(result => {
      this.categories.push(result);
    }, error => console.error(error));
  }

  add(category: Category) {
    this.http.post(this.uri, category)
      .subscribe(res => this.get(category.id));
  }
}

interface Category {
  id: string;
  name: number;
}
