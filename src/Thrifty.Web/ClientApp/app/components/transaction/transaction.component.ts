import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'transaction',
    templateUrl: './transaction.component.html'
})
export class TransactionComponent {
    public currentCount = 0;

    public ledgers = [];

    public creditAccount: string;
    public debitAccount: string;
    public amount: number;
    public description: string;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.loadLedgers();
    }

    private loadLedgers() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.get(this.baseUrl + 'api/ledger', options).subscribe(result => {
            this.ledgers = result.json();
        }, error => console.error(error));
    }

    public incrementCounter() {
        this.currentCount++;
    }



    public createTransaction() {

        let body = JSON.stringify({
            'creditAccount': this.creditAccount,
            'debitAccount': this.debitAccount,
            'amount': this.amount,
            'description': this.description
        });

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.baseUrl + 'api/Transaction', body, options).subscribe(result => {
            //this.forecasts = result.json() as WeatherForecast[];
            console.log("Transaction created!");
        }, error => console.error(error));
    }
}
