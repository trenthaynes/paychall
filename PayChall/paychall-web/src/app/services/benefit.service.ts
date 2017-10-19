import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Employee } from '../models/employee';
import { Meta } from '../models/meta';
import { Cost } from '../models/cost';
import { Discount } from '../models/discount';

@Injectable()
export class BenefitService {

  private baseUrl = 'http://localhost:5000/api/benefits';
  private employeesUrl = this.baseUrl + '/employees';
  private metaUrl = this.baseUrl + '/meta';
  private costsUrl = this.baseUrl + '/costs';
  private discountsUrl = this.baseUrl + '/discounts';
  
  constructor(private http: Http) { };
  
  getDiscounts(): Promise<Discount[]> {
    return this.http.get(this.discountsUrl)
              .toPromise()
              .then(response => response.json())
              .catch(this.handleError);
  };
  getCosts(): Promise<Cost[]> {
    return this.http.get(this.costsUrl)
              .toPromise()
              .then(response => response.json())
              .catch(this.handleError);
  };
  getMeta(): Promise<Meta> {
    return this.http.get(this.metaUrl)
              .toPromise()
              .then(response => response.json())
              .catch(this.handleError);
  };
  getEmployees(): Promise<Employee[]> {
    return this.http.get(this.employeesUrl)
              .toPromise()
              .then(response => response.json())
              .catch(this.handleError);
  };
  getEmployee(id: number): Promise<Employee> {
    const url = `${this.employeesUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json())
      .catch(this.handleError);
  };

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  };
}
