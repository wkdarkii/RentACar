const form=document.getElementById("car-form");
const titleElement=document.querySelector("#title");
const priceElemet = document.querySelector("#price");
const urlElement = document.querySelector("#url");
const cardbody = document.querySelectorAll(".card-body")[1];
const clear=document.getElementById("clear-cars");


// UI objesini başlatma

const ui = new UI();

const storage= new Storage();

//tüm eventleri yükleme

eventlisteners();

function eventlisteners() {
    form.addEventListener("submit",addCar);

    document.addEventListener("DOMContentLoaded",function(){

            let cars = storage.getCarsFromStorage();
            ui.loadAllCars(cars);
    });

    cardbody.addEventListener("click",delateCar);
    clear.addEventListener("click",clearAllCars);
}

function addCar(e) {
    const title=titleElement.value
    const price=priceElemet.value;
    const url = urlElement.value;

    if (title===""||price===""||url==="") {
        ui.displaymessages("tüm alanları doldurun...","danger")
    }
    else{
        //yeni arac

        const newCar=new car(title,price,url);

        ui.addCarToUI(newCar);//arayüze arac ekleme

        storage.addCarToStorage(newCar)
        ui.displaymessages("Arac başarıyla eklendi...","success");

    }

    ui.clearInput(titleElement,urlElement,priceElemet);

    e.preventDefault();
}

function delateCar(e) {
    
    if (e.target.id==="delete-car") {
        ui.delateCarFromUI(e.target);

        storage.delateCarFromStorage(e.target.parentElement.previousElementSibling.previousElementSibling.textContent);
   // console.log(e.target.parentElement.previousElementSibling.previousElementSibling.textContent)
    
        ui.displaymessages("Silme işlemi başarıyla gercekleşti...","success");
    }
}

function clearAllCars() {
    if (confirm("Tüm Araçlar silinecek bundan emin misiniz!!...")) {
        ui.clearAllCarsFromUI();
        storage.clearAllCarsFromStorage(); // Storage sınıfındaki metodun çağrılması
        ui.displaymessages("Tüm araçlar silindi.", "success");
    }
}
