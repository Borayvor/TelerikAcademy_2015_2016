function createImagesPreviewer(selector, items) {
  var root = document.querySelector(selector);
  root.className += ' image-previewer';

  var table = document.createElement('table');
  table.style.height = '400px';
  table.style.overflow = 'hidden';

  var theRow = document.createElement('tr');
  table.appendChild(theRow);
  root.appendChild(table);

  /* Left panel */
  var leftPanel = document.createElement('td');
  leftPanel.className += ' left-panel';

  var title = document.createElement('h1');
  title.innerHTML = items[0].title;
  title.style.textAlign = 'center';

  var bigImage = document.createElement('img');
  bigImage.src = items[0].url;
  bigImage.style.width = '400px';

  leftPanel.appendChild(title);
  leftPanel.appendChild(bigImage);
  /* End of left panel */

  /* Right panel */
  var rightPanel = document.createElement('td');
  rightPanel.className += ' right-panel';
  rightPanel.style.textAlign = 'center';
  rightPanel.style.overflowY = 'scroll';

  var filter = document.createElement('div');
  filter.className = 'filter';
  var filterTitle = document.createElement('span');
  filterTitle.innerHTML = 'Filter';
  var filterBox = document.createElement('input');
  filterBox.type = 'text';
  filter.appendChild(filterTitle);
  filter.appendChild(document.createElement('br'));
  filter.appendChild(filterBox);

  rightPanel.appendChild(filter);

  var imgsList = document.createElement('ul');
  imgsList.style.listStyleType = 'none';
  imgsList.style.height = '200px';
  for (var i = 0; i < items.length; i += 1) {

    var imgItem = document.createElement('li');
    imgItem.setAttribute('data-index', i + '');
    imgItem.style.width = '150px';

    var imgItemTitle = document.createElement('span');
    imgItemTitle.innerHTML = items[i].title;
    imgItem.appendChild(imgItemTitle);

    var imgItemImg = document.createElement('img');
    imgItemImg.src = items[i].url;
    imgItemImg.style.maxWidth = '100%';

    imgItem.appendChild(imgItemImg);
    imgsList.appendChild(imgItem);
  }

  rightPanel.appendChild(imgsList);

  /* End of right panel */

  theRow.appendChild(leftPanel);
  theRow.appendChild(rightPanel);

  function changeBackground(element, colorAsString) {
    if (element.nodeName === 'LI' || element.parentNode.nodeName === 'LI') {
      var currentElement;

      if (element.nodeName === 'LI') {
        currentElement = element;
      } else {
        currentElement = element.parentNode;
      }

      currentElement.style.background = colorAsString;
    }
  }

  function changeBigImage(element) {
    if (element.nodeName === 'LI' || element.parentNode.nodeName === 'LI') {
      var currentElement;

      if (element.nodeName === 'LI') {
        currentElement = element;
      } else {
        currentElement = element.parentNode;
      }

      var index = currentElement.getAttribute('data-index');
      title.innerHTML = items[index].title;
      bigImage.src = items[index].url;
    }
  }

  function find(element) {
    var value = element.value;
    var elements = imgsList.querySelectorAll('[data-index]');

    for (var i = 0; i < items.length; i += 1) {
      if (items[i].title.toLowerCase().indexOf(value.toLowerCase()) === -1) {
        elements[i].style.display = 'none';
      } else {
        elements[i].style.display = 'block';
      }
    }
  }

  rightPanel.addEventListener('mouseover', function (ev) {
    var targetElement = ev.target;
    changeBackground(targetElement, "gray");
  }, false);

  rightPanel.addEventListener('mouseout', function (ev) {
    var targetElement = ev.target;
    changeBackground(targetElement, "none");
  }, false);

  rightPanel.addEventListener('click', function (ev) {
    var targetElement = ev.target;
    changeBigImage(targetElement);
  }, false);

  filterBox.addEventListener('keyup', function (ev) {
    var targetElement = ev.target;
    find(targetElement);
  }, false);
}