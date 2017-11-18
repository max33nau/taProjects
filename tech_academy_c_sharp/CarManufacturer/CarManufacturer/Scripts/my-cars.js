function car(make, model, year, color, id) {
  return {
    make: ko.observable(make),
    model: ko.observable(model),
    year: ko.observable(year),
    color: ko.observable(color),
    id: id
  }
} 

function validCar() {
  return {
    make: ko.observable(false),
    model: ko.observable(false),
    year: ko.observable(false),
    color: ko.observable(false)
  }
} 

$.ajax({
    type: 'GET',
    url: 'WebServices/Cars.asmx/Get',
    dataType: 'json',
    contentType: 'application/json; charset=utf-8',
    success: function (response) {
        if (response.d.data) {
            var cars = $.parseJSON(response.d.data);
            ko.applyBindings(new MyViewModel(cars));
        }
        
    },
    error: function (error) {
        console.log(error);
    }
});

function MyViewModel(cars) {
  var self = this;
  self.submitAttempt = ko.observable(false);
  self.cars = ko.observableArray([]);
  $.each(cars, function (index, value) {
      self.cars.push(
          new car(value.Make, value.Model, value.Year, value.Color, value.CarId)
      );
  });
  self.valid = new validCar();
  self.newCar = new car('', '', '', '');
  self.addCar = function() {
    var newCar = {
      make: self.newCar.make(), model: self.newCar.model(),
      year: Number(self.newCar.year()), color: self.newCar.color()
    }
    var valid = _validateCar(newCar);
    self.submitAttempt(true);
    if (valid) {
      $.ajax({
        type: 'POST',
        url: 'WebServices/Cars.asmx/Add',
        dataType: 'json',
        data: JSON.stringify(newCar),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
          var carDetails = $.parseJSON(response.d.data);
          self.cars.push(
            new car(carDetails.Make, carDetails.Model, carDetails.Year, carDetails.Color, carDetails.CarId)
          );
          self.newCar.make('');
          self.newCar.model('');
          self.newCar.year('');
          self.newCar.color('');
          self.submitAttempt(false); 
        },
        error: function (error) {
            console.log(error);
        }
      });
    }
  }
  self.removeCar = function(car) {
    var confirmation = window.confirm('Are you sure you want to remove this car?');
    if (confirmation) {
      $.ajax({
        type: 'POST',
        url: 'WebServices/Cars.asmx/Remove',
        dataType: 'json',
        data: JSON.stringify({ carId: car.id }),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
          self.cars.remove(car);
        },
        error: function (error) {
            console.log(error);
        }
      });
      
    }
  }
}

function _validateCar(car) {
  var valid = true;
  $.each(car, function(key,value) {
    if (!value) { valid = false; } 
  });
  return valid;
}



