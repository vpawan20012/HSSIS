import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetSubCategoryAddComponent } from './asset-sub-category-add.component';

describe('AssetSubCategoryAddComponent', () => {
  let component: AssetSubCategoryAddComponent;
  let fixture: ComponentFixture<AssetSubCategoryAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetSubCategoryAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssetSubCategoryAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
