import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

// import { CustomerOrdersModalComponent } from '../components/customer-orders-modal/customer-orders-modal.component';

import { PeopleService } from '../services/people.service';

import { People } from '../interfaces/people';
// import { NewOrderDialogComponent } from '../components/new-order-dialog/new-order-dialog.component';

@Component({
  selector: 'app-people',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
  ],
  templateUrl: './people.component.html',
  styleUrl: './people.component.css',
})
export class PeopleComponent implements OnInit {
  loadingSearch = false;
  people: MatTableDataSource<People> = new MatTableDataSource();
  form: FormGroup;

  displayedColumns: string[] = ['name', 'lastName', 'age', 'email', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private fb: FormBuilder,
    private service: PeopleService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
  ) {
    this.form = this.fb.group({
      name: [''],
      lastName: [''],
      email: [''],
      age: [''],
    });
  }

  ngOnInit(): void {
    this.getDataPeople('');
  }

  getDataPeople(companyName: string): void {
    this.service.getPeople({}).subscribe((data) => {
      this.people.data = data;
      this.loadingSearch = false;
    });
  }

  applyFilter(filterValue: string) {
    this.people.filter = filterValue.trim().toLowerCase();
  }

  onSearch(): void {
    const searchTerm = this.form.get('search')?.value;
    this.loadingSearch = true;
    this.getDataPeople(searchTerm);
    this.loadingSearch = false;
  }
}
