// Funci�n para manejar la selecci�n de colores
function setColor(colorCode, event) {
    event.preventDefault(); // Prevenir comportamiento predeterminado del enlace
    if (colorCode === 'none') {
        $('#selected-color').val(''); // Limpiar el campo oculto si se selecciona "Sin Color"
    } else {
        $('#selected-color').val(colorCode); // Asignar el c�digo de color al campo oculto
    }
    applyFilters(); // Aplicar filtros despu�s de seleccionar un color
}

// Funci�n para limpiar el filtro de color seleccionado
function clearColorFilter(event) {
    event.preventDefault(); // Prevenir comportamiento predeterminado del enlace
    $('#selected-color').val(''); // Limpiar el campo oculto de color seleccionado
    applyFilters(); // Aplicar filtros despu�s de limpiar el color seleccionado
}

function applyFilters(pageNumber = 1) {
    var selectedSubcategory = $('.subcategory-link.selected').data('subcategory-id');
    var selectedBrands = [];
    $('.brand-checkbox:checked').each(function () {
        selectedBrands.push($(this).val());
    });
    var minPrice = $('#min-price').val();
    var maxPrice = $('#max-price').val();
    var selectedColor = $('#selected-color').val(); // Obtener el color seleccionado
    var selectedValue = $('#orderSelect').val(); // Obtener el valor seleccionado del orden

    $.ajax({
        url: getProductsByFiltersUrl, // Usar la URL generada
        type: 'GET',
        data: {
            sortOrder: selectedValue,
            subcategoryId: selectedSubcategory,
            brands: selectedBrands,
            minPrice: minPrice,
            maxPrice: maxPrice,
            color: selectedColor, // Pasar el color como par�metro
            pageNumber: pageNumber // Pasar el n�mero de p�gina como par�metro
        },
        traditional: true,
        success: function (result) {
            $('#product-list').html(result);
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar productos:', {
                status: status,
                error: error,
                responseText: xhr.responseText
            });
        }

    });
}

$(document).ready(function () {
    // Inicializaci�n del slider de precios con ion.rangeSlider
    var priceSlider = $("#price-slider").ionRangeSlider({
        type: "double",
        min: 1,
        max: 1000,
        from: 1,
        to: 1000,
        step: 1,
        grid: true,
        grid_num: 10,
        postfix: "$",
        onStart: function (data) {
            $("#min-price").val(data.from);
            $("#max-price").val(data.to);
        },
        onChange: function (data) {
            $("#min-price").val(data.from);
            $("#max-price").val(data.to);
        }
    }).data("ionRangeSlider");

    // Evento para el bot�n de aplicar filtro de precio
    $('#apply-price-filter').click(function () {
        applyFilters();
    });

    // Evento para checkbox de marcas
    $('.brand-checkbox').change(function () {
        applyFilters();
    });

    // Evento para enlaces de categor�as
    $('.category-link').click(function (e) {
        e.preventDefault();
        var $this = $(this);
        var $subcategoryList = $this.next('.subcategory-list');
        $('.subcategory-list').not($subcategoryList).slideUp();
        $subcategoryList.slideToggle();
        applyFilters(); // Aplicar filtros al seleccionar una categor�a
    });

    // Evento para enlaces de subcategor�as
    $('.subcategory-link').click(function (e) {
        e.preventDefault();
        $('.subcategory-link').removeClass('selected');
        $(this).addClass('selected');
        applyFilters(); // Aplicar filtros al seleccionar una subcategor�a
    });

    // Evento para el cambio del selectbox de ordenamiento
    $('#orderSelect').change(function () {
        applyFilters();
    });

    // Inicializar los valores de los inputs min-price y max-price
    $("#min-price").val(priceSlider.result.from);
    $("#max-price").val(priceSlider.result.to);
});
