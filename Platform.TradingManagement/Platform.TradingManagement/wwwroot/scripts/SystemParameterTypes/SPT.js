function onGridDataSourceRequestEnd(e) {
    if (e.type == "update" || e.type == "destroy" || e.type == "Cancel" || e.type == "create") {
        this.read();
    }

}

function onSystemParametersGridEdit(e) {
    basePerson.PersonId = e.model.Persons.PersonId;
    basePerson.PersonName = e.model.Persons.PersonName;
    basePerson.PersonType = e.model.Persons.PersonType;

    if (!e.model.isNew()) {
        e.container.find('[data-role=dropdownlist]').data().kendoDropDownList.enable(false);
    }
}