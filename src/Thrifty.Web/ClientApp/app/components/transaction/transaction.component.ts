import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'transaction',
    templateUrl: './transaction.component.html'
})
export class TransactionComponent {
    public currentCount = 0;

    public ledgers = [];
    public transactions = [];

    public creditAccount: string;
    public debitAccount: string;
    public amount: number;
    public description: string;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.loadLedgers();
        this.loadTransactions();
    }

    private loadTransactions() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.get(this.baseUrl + 'api/transaction', options).subscribe(result => {
            this.transactions = result.json();
        }, error => console.error(error));
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
            console.log("Transaction created!");
            this.loadTransactions();
        }, error => console.error(error));
    }
}
