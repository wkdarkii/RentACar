function Storage() {
    // Storage.prototype.addCarToStorage içerisinde tanımlama yapıyorsunuz ancak Storage prototype'ını burada tanımlamanız gerekiyor.

    // Bu nedenle addCarToStorage fonksiyonunu doğrudan Storage fonksiyonunun dışına almalısınız.
}

Storage.prototype.addCarToStorage = function (newCar) {
    let cars = this.getCarsFromStorage(); // 'this' anahtar kelimesini doğru bir şekilde kullanmalısınız.

    cars.push(newCar);

    localStorage.setItem("cars", JSON.stringify(cars));
};

Storage.prototype.getCarsFromStorage = function () {
    let cars;

    if (localStorage.getItem("cars") === null) {
        cars = [];
    } else {
        // Burada düzeltilmesi gereken bir hata var. 'JSON.parse' fonksiyonu eksik.
        cars = JSON.parse(localStorage.getItem("cars"));
    }
    return cars;
};

Storage.prototype.delateCarFromStorage = function (cartitle) {
    let cars = this.getCarsFromStorage(); // Mevcut arabaları getir

    cars.forEach(function (car, index) {
        if (car.title === cartitle) {
            cars.splice(index, 1); // Belirtilen arabayı listeden kaldır
        }
    });

    localStorage.setItem("cars", JSON.stringify(cars)); // Güncellenmiş arabaları tekrar local storage'a kaydet
};

Storage.prototype.clearAllCarsFromStorage = function () {
    localStorage.removeItem("cars");
};
