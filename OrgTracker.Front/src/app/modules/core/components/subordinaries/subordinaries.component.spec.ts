import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubordinariesComponent } from './subordinaries.component';

describe('SubordinariesComponent', () => {
  let component: SubordinariesComponent;
  let fixture: ComponentFixture<SubordinariesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubordinariesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubordinariesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
