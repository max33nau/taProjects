function car(make, model, year, color) {
  return {
    make: ko.observable(make),
    model: ko.observable(model),
    year: ko.observable(year),
    color: ko.observable(color)
  }
} 
function MyViewModel() {
  var self = this;

  self.cars = ko.observableArray([
    new car('ford', 'mustang', 1990, 'red')  
  ]),
  self.newCar = new car('', '', '', '');
  self.addCar = function() {
    var newCar = {
      make: self.newCar.make(), model: self.newCar.model(),
      year: self.newCar.year(), color: self.newCar.color()
    }
    self.cars.push(newCar);
    self.newCar.make('');
    self.newCar.model('');
    self.newCar.year('');
    self.newCar.color('');
  }
  self.removeCar = function(car) {
    var confirmation = window.confirm('Are you sure you want to remove this car?');
    if (confirmation) {
      self.cars.remove(car);
    }
  }
}

 ko.applyBindings(new MyViewModel());

