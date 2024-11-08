﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using DocumentFormat.OpenXml.Spreadsheet;
using Moq;
using PdfSharp.Drawing;

namespace CommonTestUtilities.Repositories;

public class ExpensesReadOnlyRepositoryBuilder
{
    private readonly Mock<IExpensesReadOnlyRepository> _repository;

    public ExpensesReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IExpensesReadOnlyRepository>();
    }

    public ExpensesReadOnlyRepositoryBuilder GetAll(User user, List<Expense> expenses)
    {
        _repository.Setup(expensesReadOnly => expensesReadOnly.GetAll(user)).ReturnsAsync(expenses);

        return this;
    }

    public ExpensesReadOnlyRepositoryBuilder GetById(User user, Expense? expense)
    {
        if (expense is not null)
            _repository.Setup(expensesReadOnly => expensesReadOnly.GetById(user, expense.Id)).ReturnsAsync(expense);

        return this;
    }
    public ExpensesReadOnlyRepositoryBuilder FilterByMonth(User user, List<Expense> expenses)
    {
        _repository.Setup(expensesReadOnly => expensesReadOnly.FilterByMonth(user, It.IsAny<DateOnly>())).ReturnsAsync(expenses);

        return this;
    }

    public IExpensesReadOnlyRepository Build() => _repository.Object;
}
