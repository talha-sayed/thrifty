import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'balance-sheet',
    templateUrl: './balancesheet.component.html'
})
export class BalanceSheetComponent {
    
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }
}
