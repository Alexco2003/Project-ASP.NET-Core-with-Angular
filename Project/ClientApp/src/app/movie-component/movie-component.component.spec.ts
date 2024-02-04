import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieComponentComponent } from './movie-component.component';

describe('MovieComponentComponent', () => {
  let component: MovieComponentComponent;
  let fixture: ComponentFixture<MovieComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
