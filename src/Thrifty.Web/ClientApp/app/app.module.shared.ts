import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { TransactionComponent } from './components/transaction/transaction.component';
import { LedgerComponent } from './components/core/ledger/ledger.component';
import { BalanceSheetComponent } from './components/core/balancesheet/balancesheet.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        TransactionComponent,
        LedgerComponent,
        FetchDataComponent,
        HomeComponent,
        BalanceSheetComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'transaction', component: TransactionComponent },
            { path: 'core/ledger', component: LedgerComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'core/balance-sheet', component: BalanceSheetComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
