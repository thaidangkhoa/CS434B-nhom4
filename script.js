// Danh sách sản phẩm mẫu
const products = [
    { id: 1, name: "Arsenal Home 23/24", price: 250000, image: "images/h1.jpg" },
    { id: 2, name: "Arsenal Away 23/24", price: 250000, image: "images/h3.jpg" },
    { id: 3, name: "Real Madrid Home 23/24", price: 250000, image: "images/h4.jpg" },
    { id: 4, name: "Real Madrid Away 23/24", price: 250000, image: "images/h5.jpg" },
    { id: 5, name: "Arsenal Home 24/25", price: 300000, image: "images/h10.jpg" },
    { id: 6, name: "Bayern Away 24/25", price: 300000, image: "images/h11.jpg" },
    { id: 7, name: "Đức Home 24/25", price: 350000, image: "images/h12.jpg" },
    { id: 8, name: "Argentina Away 24/25", price: 350000, image: "images/h13.jpg" }
  ];
  
  
  
  // Render danh sách sản phẩm
  function renderProducts(filteredProducts) {
    const productList = document.querySelector(".row");
    productList.innerHTML = ""; // Xóa nội dung cũ
  
    if (filteredProducts.length === 0) {
      productList.innerHTML = "<p>Không tìm thấy sản phẩm nào.</p>";
      return;
    }
  
    filteredProducts.forEach((product) => {
      const productItem = document.createElement("div");
      productItem.className = "col-4";
      productItem.innerHTML = `
        <a href="products-details.html"><img src="${product.image}" alt="${product.name}"></a>
        <a href="products-details.html"><h4>${product.name}</h4></a>
        <p>${product.price.toLocaleString()} VND</p>
        <button onclick="addToCart(${product.id})">Thêm vào giỏ hàng</button>
      `;
      productList.appendChild(productItem);
    });
  }
  
  // Hàm tìm kiếm sản phẩm
  function searchProducts() {
    const searchInput = document.querySelector(".search-form input").value.toLowerCase();
    const filteredProducts = products.filter((product) =>
      product.name.toLowerCase().includes(searchInput)
    );
    renderProducts(filteredProducts);
  }
  
  // Lắng nghe sự kiện nhập vào ô tìm kiếm
  document.querySelector(".search-form input").addEventListener("input", searchProducts);
  document.addEventListener("DOMContentLoaded", () => {
    renderCart();
});
// Lấy giỏ hàng từ localStorage
let cart = JSON.parse(localStorage.getItem("cart")) || [];
// Hàm thêm sản phẩm vào giỏ hàng
function addToCart(productId) {
  const product = products.find((item) => item.id === productId);
  if (product) {
      cart.push(product);
      saveCart(); // Lưu vào localStorage
      alert(`${product.name} đã được thêm vào giỏ hàng!`);
      renderCart(); // Hiển thị giỏ hàng
  }
}

// Tải giỏ hàng từ localStorage và hiển thị
function loadCart() {
  const savedCart = localStorage.getItem("cart");
  cart = savedCart ? JSON.parse(savedCart) : [];
  renderCart();
}
// Xóa sản phẩm khỏi giỏ hàng
function removeFromCart(productId) {
  cart = cart.filter((item) => item.id !== productId);
  saveCart();
  alert("Sản phẩm đã được xóa khỏi giỏ hàng!");
  renderCart();
}


function saveCart() {
  localStorage.setItem("cart", JSON.stringify(cart));
}
// Lắng nghe sự kiện DOMContentLoaded
document.addEventListener("DOMContentLoaded", () => {
  loadCart(); // Tải giỏ hàng từ localStorage và hiển thị
});
// Render giỏ hàng
function renderCart() {
  const cartList = document.querySelector(".cart");
  if (!cartList) return; // Nếu không có phần tử giỏ hàng, thoát

  cartList.innerHTML = "";

  if (cart.length === 0) {
    cartList.innerHTML = "<p>Giỏ hàng trống.</p>";
    return;
  }

  let total = 0;

  cart.forEach((product) => {
    const cartItem = document.createElement("div");
    cartItem.className = "cart-item";
    cartItem.innerHTML = `
      <div>
        <img src="${product.image}" alt="${product.name}" width="50">
        <p>${product.name} - ${product.price.toLocaleString()} VND</p>
        <button onclick="removeFromCart(${product.id})">Xóa</button>
      </div>
    `;
    total += product.price;
    cartList.appendChild(cartItem);
  });

  const totalDiv = document.createElement("div");
  totalDiv.className = "cart-total";
  totalDiv.innerHTML = `<h3>Tổng cộng: ${total.toLocaleString()} VND</h3>`;

  const checkoutButton = document.createElement("button");
  checkoutButton.textContent = "Thanh toán";
  checkoutButton.onclick = handleCheckout;

  totalDiv.appendChild(checkoutButton);
  cartList.appendChild(totalDiv);
}

// Xử lý thanh toán
function handleCheckout() {
  if (cart.length === 0) {
    alert("Giỏ hàng trống. Không thể thực hiện thanh toán.");
    return;
  }
  // Xóa giao diện thanh toán cũ nếu có
  const existingPaymentMethods = document.querySelector(".payment-methods");
  if (existingPaymentMethods) existingPaymentMethods.remove();

  // Tạo giao diện thanh toán
  const paymentMethods = document.createElement("div");
  paymentMethods.className = "payment-methods";
  paymentMethods.innerHTML = `
    <h3>Chọn phương thức thanh toán:</h3>
    <button onclick="payWithCard()">Thanh toán bằng thẻ ngân hàng</button>
    <button onclick="payWithQRCode()">Quét mã QR</button>
    <button onclick="cancelPayment()">Hủy</button>
    
  `;
// Thêm giao diện vào body
document.body.appendChild(paymentMethods);
}

function payWithCard() {
  alert("Đang xử lý thanh toán bằng thẻ ngân hàng...");
  finalizePayment();
}


// Hàm xử lý thanh toán bằng mã QR
function payWithQRCode() {
  // Thông báo cho người dùng
  alert("Vui lòng quét mã QR để hoàn tất thanh toán.");
  
  // Ẩn các phần không cần thiết (ví dụ như phương thức thanh toán khác)
  document.querySelector('.payment-methods').style.display = 'none';
  
  // Hiển thị phần chứa mã QR
  document.querySelector('.qr-container').style.display = 'block';

  // Tạo mã QR với nội dung thanh toán
  const qrText = "Thanh toán thành công! Cảm ơn bạn đã mua sắm."; // Thông tin thanh toán có thể thay đổi
  
  // Lấy phần tử canvas để vẽ mã QR
  const qrCanvas = document.getElementById('qr-code');
  
  // Sử dụng thư viện qrcode.js để tạo mã QR
  QRCode.toCanvas(qrCanvas, qrText, (error) => {
    if (error) {
      console.error(error);
    } else {
      console.log("Mã QR đã được tạo thành công.");
    }
  });
}

// Hàm hủy thanh toán và ẩn giao diện thanh toán
function cancelPayment() {
  // Ẩn giao diện thanh toán và mã QR
  const paymentMethods = document.querySelector('.payment-methods');
  const qrContainer = document.querySelector('.qr-container');
 
  // Đảm bảo chắc chắn là chúng ta đang thay đổi display đúng
  if (paymentMethods) {
    paymentMethods.style.display = 'block';  // Hiển thị lại phương thức thanh toán
  }
  if (qrContainer) {
    qrContainer.style.display = 'none';  // Ẩn phần mã QR
  }
  
  // Reset lại canvas QR code (tuỳ chọn)
  const qrCanvas = document.getElementById('qr-code');
  if (qrCanvas) {
    // Không cần reset kích thước canvas, chỉ cần ẩn phần tử là đủ
    qrCanvas.width = 0; // Reset kích thước canvas
    qrCanvas.height = 0; // Reset kích thước canvas
  }

  console.log("Đã đóng mã QR.");
}


// Hàm thanh toán qua thẻ ngân hàng
function payWithCard() {
  alert("Đang xử lý thanh toán bằng thẻ ngân hàng...");
  finalizePayment();
}

// Hàm hoàn tất thanh toán
function finalizePayment() {
  alert("Thanh toán thành công! Cảm ơn bạn đã mua sắm tại cửa hàng.");
  // Xóa giỏ hàng sau khi thanh toán thành công
  cart = [];
  saveCart(); // Lưu giỏ hàng trống vào localStorage
  renderCart();
  cancelPayment(); // Ẩn giao diện thanh toán
}

function cancelPayment() {
  const paymentMethods = document.querySelector(".payment-methods");
  if (paymentMethods) paymentMethods.remove();
}

function finalizePayment() {
  alert("Thanh toán thành công! Cảm ơn bạn đã mua sắm tại cửa hàng.");
  cart = [];
  saveCart(); // Xóa giỏ hàng trong localStorage
  renderCart();
  cancelPayment();
}
// Khởi tạo giỏ hàng khi tải trang
loadCart();
  // Hàm đăng ký
function registerUser() {
    const username = document.querySelector("#RegForm input[placeholder='Username']").value;
    const email = document.querySelector("#RegForm input[placeholder='Email']").value;
    const password = document.querySelector("#RegForm input[placeholder='Password']").value;
  
    if (!username || !email || !password) {
      alert("Vui lòng nhập đầy đủ thông tin!");
      return;
    }
  
    const users = JSON.parse(localStorage.getItem("users")) || [];
  
    // Kiểm tra xem email đã được đăng ký chưa
    if (users.some((user) => user.email === email)) {
      alert("Email này đã được sử dụng!");
      return;
    }
  
    users.push({ username, email, password });
    localStorage.setItem("users", JSON.stringify(users));
    alert("Đăng ký thành công!");
    login(); // Chuyển sang form đăng nhập
  }
  
  // Hàm đăng nhập
  function loginUser() {
    const username = document.querySelector("#LoginForm input[placeholder='Username']").value;
    const password = document.querySelector("#LoginForm input[placeholder='Password']").value;
  
    if (!username || !password) {
      alert("Vui lòng nhập đầy đủ thông tin!");
      return;
    }
  
    const users = JSON.parse(localStorage.getItem("users")) || [];
    const user = users.find((user) => user.username === username && user.password === password);
  
    if (user) {
      alert(`Chào mừng, ${user.username}!`);
      // Chuyển đến trang chính hoặc xử lý logic khác
      window.location.href = "index.html";
    } else {
      alert("Tên đăng nhập hoặc mật khẩu không đúng!");
    }
   
  }
  
  
  
 
  
