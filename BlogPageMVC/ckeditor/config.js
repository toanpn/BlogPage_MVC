
CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
        {
            name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'forms', groups: ['forms'] },
        '/',
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert', 'base64image'] },
        '/',
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'others', groups: ['others'] },
        { name: 'about', groups: ['about'] }
    ];

    config.removeButtons = 'Iframe,NewPage,Save,About';
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.height = 500;        // 500 pixels high.
    config.language = 'vi';
    config.extraPlugins = "base64image";
    config.uiColor = '#FFCB64';
    config.font_defaultLabel = 'Arial';
    config.fontSize_defaultLabel = '22px';

};
        //CKEDITOR.config.extraPlugins = "base64image";
